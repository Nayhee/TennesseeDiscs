import React from "react"
import { Route, Routes, Navigate} from "react-router-dom"
import { Home } from "../Home"
import { DiscList } from './disc/DiscList'
import DiscDetails from './disc/DiscDetails';
import DiscForm from './disc/DiscForm'
import DiscEditForm  from "./disc/DiscEditForm"
import Login from "./auth/Login";
import Register from "./auth/Register";
import Cart from "../components/cart/Cart";

export default function ApplicationViews({ isLoggedIn, user}) {
    
    return (
            <main>
                <Routes>
                        <Route path="/">

                                <Route index element={isLoggedIn ? <Home/> : <Navigate to="/login"/>} />

                                <Route path="discs">
                                        <Route index element={<DiscList user={user} />} />
                                        <Route path="discs/:id" element={<DiscDetails />} />
                                        <Route path="discs/create" element={<DiscForm user={user} />} />
                                        <Route path="edit/:discId" element={<DiscEditForm />} />
                                </Route>

                                <Route path="login" element={<Login />} />
                                <Route path="register" element={<Register />} />

                                <Route path="cart" element={<Cart user={user} />} />

                        </Route>
                </Routes>
            </main>
    )
}