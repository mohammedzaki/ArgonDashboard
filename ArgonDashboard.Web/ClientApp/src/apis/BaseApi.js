import axios from 'axios';

export default class BaseApi {

    getBaseUrl() {
        return '/api';
    }

    async getData(path) {
        console.log(`${this.getBaseUrl()}/${path}`);
        let response = await axios.get(`${this.getBaseUrl()}/${path}`);
        return response.data;
    }
}