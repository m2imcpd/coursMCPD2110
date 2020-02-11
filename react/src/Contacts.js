import React, {useState, useEffect} from "react"
import {Contact} from "./Contact"

export const Contacts = (props) => {

    const [contacts, setContacts] = useState([])
    useEffect(() => {
        fetch("http://localhost:60071/contact",{
            method : 'GET'
        }).then((res)=>res.json()).then((response) => {
            setContacts(response)
        })
    }, [contacts])
    return(
        <div><h1>Liste des contacts</h1>
            {contacts.map((contact, index)=> {
                return(
                    <Contact key={index} contact={contact}></Contact>
                )
            })}
        </div>
    )
}