import React, {useState, useEffect} from "react"
import {Client} from "./Client"
export const Clients = (props) => {
    const [existClient, setExistClient] = useState(false)
    const [clients, setClients] = useState([])
    useEffect(() => {
        fetch("http://localhost:60071/client",{
            method : 'GET'
        }).then((res)=>res.json()).then((response) => {
            setClients(response)
        })
        return () => {
            //Supprimer la request fetch 
        };
    }, [existClient])
    return(
        <div>
            <h1>Liste clients {existClient}</h1>
            {clients.map((c, index)=> <Client key={index} nom={c.nom} prenom={c.prenom} telephone={c.telephone}></Client>)}
            <button onClick={()=> {setExistClient(!existClient); console.log(existClient)}}>changer state exist client</button>
        </div>
    )
}

// export class Clients extends React.Component {
//     constructor(props)
//     {
//         super(props);
//         this.state = {
//             existClient : false,
//             clients : null
//         }
//     }

//     componentDidMount(){
//         fetch("http://localhost:60071/client",{
//             method : 'GET'
//         }).then((res)=>res.json()).then((response) => {
//             this.setState({clients : response})
//         })
//     }

//     render() {
//         return (
//             <div>
//             <h1>Liste clients {this.state.existClient.toString()}</h1>
//             {this.stateclients.map((c, index)=> <Client key={index} nom={c.nom} prenom={c.prenom} telephone={c.telephone}></Client>)}
//             <button onClick={()=> {this.setState({
//                 existClient : !this.state.existClient
//             })
            
//             }}>changer state exist client</button>
//         </div>
//         )
//     }
// }

