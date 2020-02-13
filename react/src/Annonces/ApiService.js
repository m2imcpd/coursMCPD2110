export const urlBase = "http://localhost:57236/"

export const postJson = (url, data) => {
    return fetch(urlBase + url, {
        method : 'POST',
        headers : {
            "content-type" : "application/json"
        },
        body : JSON.stringify(data)
    })
} 

export const putFormData = (url, data) => {
    return fetch(urlBase + url, {
        method : 'PUT',
        headers : {
            "accept" : "application/json"
        },
        body : data
    })
} 

export const get = (url) => {
    return fetch(urlBase + url, {
        method : 'GET'
    })
}