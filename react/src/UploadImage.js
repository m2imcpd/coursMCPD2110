import React, { useState, useEffect } from "react"

export const UploadImage = (props) => {
    
    const [form, setForm] = useState(new FormData())
    
    const monForm = new FormData();
    const handleImageChange = (event) => {
        //const monForm = new FormData();
        monForm.append('image', event.target.files[0])
        //setForm(monForm)
    }
    


    const upload = () => {
        
        fetch("http://localhost:60071/upload", {
            method: "POST",
            headers: {
                "Accept": "application/json"
            },
            body: monForm
        }).then((res) => res.json()).then((response) => {
            console.log(response)
        })
    }
    return (
        <div>
            <div>
                <label>Image</label>
                <input type="file" onChange={handleImageChange} />
            </div>
            <div>
                <button onClick={upload}>upload</button>
            </div>
        </div>
    )
}