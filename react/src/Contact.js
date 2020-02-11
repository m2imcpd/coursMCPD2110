import React from "react"

export const Contact = (props) => {

    return(
        <div>
            <div>Nom : {props.contact.nom}</div>
            <div>Prénom : {props.contact.prenom}</div>
            <div>Téléphone : {props.contact.telephone}</div>
            {props.contact.emails.map((email, index)=> {
                return (
                <div key={index}>Email : {email.mail}</div>
                )
            })}
        </div>
    )
}