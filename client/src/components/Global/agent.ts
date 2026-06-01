import axios from 'axios'

const agent = axios.create({
    baseURL: 'https://localhost:7189/api'
});

agent.interceptors.response.use(async (response) => {

    try{
        return response;
    } catch (err) {
        console.error(err);
        return Promise.reject(err);
    }
});

export default agent;