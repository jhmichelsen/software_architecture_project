import React, { useEffect, useState } from 'react';
import * as signalR from '@microsoft/signalr';

interface Greenhouse {
  id: number;
  waterOn: boolean;
}

interface Factory {
  id: number;
  location: string;
  greenHouseEntities: Greenhouse[];
}

function App() {
  const [factories, setFactories] = useState<Factory[]>([]);
  const [loading, setLoading] = useState(true);
  const [connectionStatus, setConnectionStatus] = useState("Disconnected");

  // Environment variables for multiple services
  const factoryApiUrl = process.env.REACT_APP_FACTORY_API || "http://localhost:5002";
  const waterApiUrl = process.env.REACT_APP_WATER_API || "http://localhost:5005";

  // Fetch factories from GreenhouseFactoryService
  useEffect(() => {
    console.log(`Factory API URL: ${factoryApiUrl}`);

    const fetchFactories = async () => {
      try {
        const response = await fetch(`${factoryApiUrl}/factory/all`);
        if (!response.ok) throw new Error(`HTTP error ${response.status}`);
        const data = await response.json();
        console.log("Fetched factories:", data);
        setFactories(data);
      } catch (err) {
        console.error("Failed to fetch factories:", err);
      } finally {
        setLoading(false);
      }
    };

    fetchFactories();
  }, [factoryApiUrl]);

  // SignalR connection to WaterService for live updates
  useEffect(() => {
  const connection = new signalR.HubConnectionBuilder()
    .withUrl(`${waterApiUrl}/waterHub`)
    .withAutomaticReconnect()
    .build();

  connection.onreconnecting(() => setConnectionStatus("Reconnecting..."));
  connection.onreconnected(() => setConnectionStatus("Connected"));
  connection.onclose(() => setConnectionStatus("Disconnected"));

  connection.on(
    "WaterStatusChanged",
    (data: { factoryId: number; greenhouseId: number; waterOn: boolean }) => {
      console.log("Received WaterStatusChanged:", data);
      setFactories(prevFactories =>
        prevFactories.map(factory =>
          factory.id === data.factoryId
            ? {
                ...factory,
                greenHouseEntities: factory.greenHouseEntities.map(gh =>
                  gh.id === data.greenhouseId ? { ...gh, waterOn: data.waterOn } : gh
                )
              }
            : factory
        )
      );
    }
  );

  // Start connection
  connection.start()
    .then(() => setConnectionStatus("Connected"))
    .catch((err: unknown) => {
      console.error("SignalR connection error:", err);
      setConnectionStatus("Disconnected");
    });

  // Cleanup: synkron funktion, der kalder async stop
  return () => {
    connection.stop().catch(err => console.error("Error stopping SignalR connection:", err));
  };
}, [waterApiUrl]);


  if (loading) return <p>Loading factories...</p>;

  return (
    <div style={{ padding: "20px" }}>
      <h1>🏭 Greenhouse Dashboard</h1>
      <p>Status: <strong>{connectionStatus}</strong></p>

      {factories.length === 0 ? (
        <p>No factories found.</p>
      ) : (
        <table border={1} cellPadding={6} style={{ borderCollapse: "collapse" }}>
          <thead>
            <tr>
              <th>Factory ID</th>
              <th>Location</th>
              <th>Greenhouse ID</th>
              <th>Water On</th>
            </tr>
          </thead>
          <tbody>
            {factories.map(factory =>
              factory.greenHouseEntities.map(gh => (
                <tr key={`${factory.id}-${gh.id}`}>
                  <td>{factory.id}</td>
                  <td>{factory.location}</td>
                  <td>{gh.id}</td>
                  <td style={{ color: gh.waterOn ? "green" : "red" }}>
                    {gh.waterOn ? "ON" : "OFF"}
                  </td>
                </tr>
              ))
            )}
          </tbody>
        </table>
      )}
    </div>
  );
}

export default App;
