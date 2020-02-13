import React from "react"
import {urlBase} from "./ApiService"
export const Annonce = (props) => {

    return (
        <div className="annonce">
            <div className="row">
                <h2 className="col-10">
                    {props.annonce.titre}
                </h2>
                <span className="col-2">
                    {props.annonce.prix} €
                </span>
            </div>
            <div className="row">
                <div className="col">
                    {props.annonce.description}
                </div>
            </div>
            <div className="row">
                {props.annonce.images.map((img, index)=><img className="col-3" src={urlBase+img.urlImage}></img>)}
            </div>
        </div>

    )
}