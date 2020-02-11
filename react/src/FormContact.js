import React, { useState, useEffect } from "react"

export const FormContact = (props) => {
    const [contact, setContact] = useState({ nom : "", prenom : "", telephone : ""})

    const textChange  = (event) => {
        const c = {
            nom : (event.target.name === 'nom') ? event.target.value : contact.nom,
            prenom : (event.target.name === 'prenom') ? event.target.value : contact.prenom,
            telephone : (event.target.name === 'telephone') ? event.target.value : contact.telephone,
        }
        setContact(c)
    }

    const submitForm = (event) => {
        event.preventDefault()
        
        fetch("http://localhost:60071/contact", {
            method : "POST",
            headers : {
                "content-type" : "application/json"
            },
            body : JSON.stringify(contact)
        }).then((res) => res.json()).then((response)=> {
            alert(response.contactId + " "+ response.message);
            setContact({ nom : "", prenom : "", telephone : ""})
            props.updateNewData(true)
        })
    }
    return (
        <div>
            <form onSubmit={submitForm}>
                <div>
                    <label>Nom : </label>
                    <input type="text" value={contact.nom} name="nom" onChange={textChange} />
                </div>
                <div>
                    <label>Prénom : </label>
                    <input type="text" value={contact.prenom} name="prenom" onChange={textChange} />
                </div>
                <div>
                    <label>Téléphone : </label>
                    <input type="text" value={contact.telephone} name="telephone" onChange={textChange} />
                </div>
                <div>
                    <button type="submit">Valider</button>
                </div>
            </form>
        </div>
    )
}