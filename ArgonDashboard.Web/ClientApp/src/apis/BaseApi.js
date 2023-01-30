import axios from 'axios';
import store from "../store";

export default class BaseApi {
    getBaseUrl() {
        return '/api';
    }

    async getData(path) {
        let response = await axios.get(`${this.getBaseUrl()}/${path}`, {
            headers: {
                'Authorization': `Bearer ${store.state.localStorage.apiAccessToken}`
            }
        });
        return response.data;
    }

    async postData(path, postData) {
        let response = await axios.post(`${this.getBaseUrl()}/${path}`, postData, {
            headers: {
                'content-type': 'application/json-patch+json',
                'Authorization': `Bearer ${store.state.localStorage.apiAccessToken}`
            }
        });
        return response.data;
    }
}