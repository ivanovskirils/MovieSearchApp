import axios from 'axios';

const axiosInstance = axios.create({
  baseURL: 'http://localhost:5029', 
});

export default axiosInstance;
