import axios from 'axios';

// Получаем токен
function getToken() {
    // Предполагая хранение токенов и seeionStorage
    return window.sessionStorage.getItem('token') || '';
}

// Создаем экземпляр axios
let service = axios.create({
    baseURL: process.env.BASE_API,
    timeout: 5000
})

// Запрос на перехват
service.interceptors.request.use(
    config => {
        if (getToken()) {
            config.headers['token'] = getToken();
            config.headers['ContentType'] = 'application/json;chartset=utf-8';
        }
        return config;
    },
    error => {
        Promise.reject(error);
    }
)

// Перехват ответа
service.interceptors.response.use(
    response => {
        let res = response.data;
        if (res.status == 0) {// Когда запрос выполнен успешно
            Promise.resolve(res);
        } else {
            // Обработка различного статуса запроса
        }
    },
    error => {
        return Promise.reject(error);
    }
)

export default service;
