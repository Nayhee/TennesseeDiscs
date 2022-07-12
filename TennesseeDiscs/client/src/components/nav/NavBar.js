import React from "react"
import { Link, useNavigate, useLocation } from "react-router-dom"
import "./NavBar.css"


export const NavBar = () => {
    
    const navigate = useNavigate();
    
    const location = useLocation();

    return (
                <>
                    
                    <div className="headerAndNav">

                        <div className="nav_logo_container">
                            <img className="nav_logo" src="Images/tnLOGO.png"/>
                        </div>

                        <div className="navFullContainer">
                            <ul className="navbar">

                                <li className="navbar__item">
                                    <Link className="navbar__link" to="/"><i class="fa-solid fa-house-chimney fa-xl"></i></Link>
                                </li>

                                <li className="navbar__item">
                                    <Link className={`navbar__link ${location.pathname === '/discs' ? 'active' : ''}`} to="/Discs">DISCS</Link>
                                </li>

                                <li className="navbar__item">
                                    <Link className={`navbar__link ${location.pathname === '/sell' ? 'active' : ''}`} to="/Bags">LEARN</Link>
                                </li>

                                {/* <li className="navbar__item">
                                    <Link className="navbar__link" to="/" onClick={handleLogout}> Logout </Link>
                                </li> */}
                                <li className="navbar__item">
                                    <Link className="navbar__link" to="/login">LOGIN</Link>
                                </li>
                                    
                            </ul>

                        </div>

                    </div>
                    
                </>
            )
}
