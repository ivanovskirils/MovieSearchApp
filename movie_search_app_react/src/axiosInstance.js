import axios from 'axios';

const axiosInstance = axios.create({
  baseURL: process.env.REACT_APP_API_URL,
  withCredentials: true
});

axiosInstance.interceptors.request.use(async (config) => {
  const response = await axios.get(`${process.env.REACT_APP_API_URL}/antiforgerytoken`, { withCredentials: true });
  const token = response.data.token;
  config.headers['RequestVerificationToken'] = token;
  return config;
});

export default axiosInstance;
