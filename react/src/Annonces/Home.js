import React from "react"
import {BrowserRouter as Router, Switch, Route} from "react-router-dom"
import { Menu } from "./Menu"
import { Annonces } from "./Annonces"
import { FormAnnonce } from "./FormAnnonce"
export const Home = (props) => {
    return(
        <Router>
            <Menu></Menu>
            <Switch>
                <Route exact path="/" >
                    <Annonces></Annonces>
                </Route>
                <Route path="/Add">
                    <FormAnnonce></FormAnnonce>
                </Route>
            </Switch>
        </Router>
    )
}