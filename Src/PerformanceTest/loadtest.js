import http from 'k6/http';
import { sleep } from 'k6';

export const options = {
    vus: 200,          // Number of virtual users/machines
    duration: '30s',
};

export default function () {
    http.post('http://localhost:5003/greenhouse-simulator/simulate/factory/1/green-house/1/soil-moisture/50');
    sleep(15); // optional
}