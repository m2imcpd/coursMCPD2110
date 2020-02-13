import React, { useState, useEffect } from "react";
import { get, postJson, putFormData } from "./ApiService"
export const FormAnnonce = (props) => {
    const [categories, setCategories] = useState([])
    const [sendImage, setSendImage] = useState(false)
    const [annonceId, setAnnonceId] = useState(0)
    const [reload, setReload] = useState(true)
    const annonce = {
        'titre': '',
        'prix': 0,
        'categorieId': 0,
        'description': ''
    }

    let formDataImage = new FormData()


    useEffect(() => {
        get("categories").then(res => res.json()).then((response) => {
            setCategories(response);
        })
    }, [reload])

    const fieldChange = (event) => {
        annonce[event.target.name] = event.target.value
    }

    const sendForm = (event) => {
        event.preventDefault()
        postJson("annonces", annonce).then(res => res.json()).then((response) => {
            if (response.annonceId > 0) {
                setAnnonceId(response.annonceId)
                setSendImage(true)
            }
            else {
                alert("erreur serveur")
            }
        })
    }

    const renderSelectCategorie = () => {
        return (
            <div className="row">
                <select onChange={fieldChange} name="categorieId" className="col form-control m-1">
                    <option></option>
                    {categories.map((cat, index) => <option key={index} value={cat.id}>{cat.titre}</option>)}
                </select>
            </div>
        )
    }



    const renderFormBase = () => {
        return (
            <form onSubmit={sendForm}>
                <div className="row">
                    <input onChange={fieldChange} type="text" placeholder="Titre annonce" className="col form-control m-1" name="titre" />
                </div>
                <div className="row">
                    <input onChange={fieldChange} type="text" placeholder="Prix Annonce" className="col form-control m-1" name="prix" />
                </div>
                {renderSelectCategorie()}
                <div className="row">
                    <textarea onChange={fieldChange} className="col form-control m-1" name="description">

                    </textarea>
                </div>
                <div className="row">
                    <button className="col btn btn-success form-control m-1" type="submit">Valider</button>
                </div>
            </form>
        )
    }
    const changeImage = (event) => {
        formDataImage = new FormData()
        formDataImage.append("image",event.target.files[0])
    }
    const uplaodImage = (event) => {
        event.preventDefault();
        putFormData("annonces/upload/"+annonceId,formDataImage).then(res=>res.json()).then(response=> {
            if(response.imageId > 0) {
                alert("image envoyée")
            }
            else {
                alert("erreur serveur");
            }
        })
    }
    const sendImageForm = () => {
        return (
            <div className="container">
                <div class="input-group">
                    <div class="custom-file">
                        <input type="file" onChange={changeImage} class="custom-file-input" id="inputGroupFile04" name="image" />
                        <label class="custom-file-label" for="inputGroupFile04">Choisir une image</label>
                    </div>
                    <div class="input-group-append">
                        <button class="btn btn-outline-secondary" onClick={uplaodImage} type="button">Upload</button>
                    </div>
                </div>
            </div>
        )
    }
    return (
        <div className="container">
            {(!sendImage) ? renderFormBase() : sendImageForm()}
        </div>
    )
}