import service from './service'

export function get(url, params) {
    return new Promise((resolve, reject) => {
        service.get(url, params).then(res => {
            resolve(res);
        }).catch(err => {
            reject(err);
        })
    })
}

export function post(url, params) {
    return new Promise((resolve, reject) => {
        service.post(url, params).then(res => {
            resolve(res);
        }).catch(err => {
            reject(err);
        })
    })
}
