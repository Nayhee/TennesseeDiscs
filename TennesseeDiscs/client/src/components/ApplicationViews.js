import React from "react"
import { Route, Routes} from "react-router-dom"
import { Home } from "../Home"
import { DiscList } from './disc/DiscList.js'
// import { DiscForm} from './disc/DiscForm'
// import { DiscEditForm } from "./disc/DiscEditForm"
import { Learn } from "../Learn";
import { Login } from "./auth/Login";
import { Register } from "./auth/Register";

export const ApplicationViews = () => {
    
    return (
        <>
            <Routes>
                    <Route exact path="/" element={
                            <Home/> 
                    } />
                    <Route exact path="/discs" element={
                            <DiscList/> 
                    } />
                    <Route exact path="/learn" element={
                            <Learn/> 
                    } />

                    <Route exact path="/login" element={Login}/>
                    <Route exact path="/register" element={Register}/>
                   
            </Routes>
        </>
    )
}