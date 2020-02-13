import React, {useState, useEffect} from "react"
import {get} from "./ApiService"
import { Annonce } from "./Annonce"
export const Annonces = (props) => {
    const [relaod, setReload] = useState(false)
    const [annonces, setAnnonces] = useState([])

    useEffect(()=> {
        get("annonces").then(res => res.json()).then(response=> {
            setAnnonces(response)
        })
    }, [relaod])
    return(
        <div>
            <h1>Liste des annonces</h1>
            {annonces.map((a, index)=><Annonce annonce={a} key={index}></Annonce>)}
        </div>
    )
}