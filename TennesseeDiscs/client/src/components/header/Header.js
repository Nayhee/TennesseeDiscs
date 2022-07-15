import React, { useState } from "react";
import { NavLink as RRNavLink } from "react-router-dom";
import {Collapse, Navbar, NavbarToggler, NavbarBrand, Nav, NavItem, NavLink} from "reactstrap";
import { logout } from "../../modules/authManager";
import { Link, useLocation } from "react-router-dom";
import "./Header.css"

export default function Header({isLoggedIn, userType}) {
    const [isOpen, setIsOpen] = useState(false);
    const toggle = () => setIsOpen(!isOpen);

    const location = useLocation();

    return (
                <>
                    
                    <div className="headerAndNav">

                        <div className="nav_logo_container">
                            <img className="nav_logo" src="Images/tnLOGO.png"/>
                        </div>

                        <div className="navFullContainer">
                            <ul className="navbar">

                                {isLoggedIn && (
                                    <li className="navbar__item">
                                        <Link className="navbar__link" to="/"><i className="fa-solid fa-house-chimney fa-xl"></i></Link>
                                    </li>
                                )}

                                {isLoggedIn && (
                                    <li className="navbar__item">
                                        <Link className={`navbar__link ${location.pathname === '/discs' ? 'active' : ''}`} to="/discs">Discs</Link>
                                    </li>
                                )}

                                {isLoggedIn && userType === 1 && (
                                    <li className="navbar__item">
                                        <Link className={`navbar__link ${location.pathname === '/admin' ? 'active' : ''}`} to="/admin">Admin</Link>
                                    </li>
                                )}

                                {isLoggedIn && (
                                    <li className="navbar__item">
                                        <Link className={`navbar__link ${location.pathname === '/cart' ? 'active' : ''}`} to="/cart">Cart</Link>
                                    </li>
                                )}

                                
                                <li className="navbar__item">
                                    <Link className={`navbar__link ${location.pathname === '/learn' ? 'active' : ''}`} to="/learn">Learn</Link>
                                </li>
                                

                                {isLoggedIn && (
                                    <li className="navbar__item">
                                        <Link className="navbar__link" to="/" onClick={logout}>Logout</Link>
                                    </li>
                                )}

                                {!isLoggedIn && (
                                    <>
                                        <li className="navbar__item">
                                            <Link className="navbar__link" to="/login">Login</Link>
                                        </li>
                                        <li className="navbar__item">
                                            <Link className="navbar__link" to="/register">Register</Link>
                                        </li>
                                    </>
                                )}
                                    
                            </ul>
                        </div>

                    </div>
                    
                </>
            )
}





// return (
//     <div>
//       <Navbar color="light" light expand="md">

//         <NavbarBrand tag={RRNavLink} to="/">
//           Tennessee Discs
//         </NavbarBrand>

//         <NavbarToggler onClick={toggle} />

//         <Collapse isOpen={isOpen} navbar>

//           <Nav className="mr-auto" navbar>
//             {/* When isLoggedIn === true, we will render the Home link */}
//             {isLoggedIn && (
//               <NavItem>
//                 <NavLink tag={RRNavLink} to="/">
//                   Home
//                 </NavLink>
//               </NavItem>
//             )}
//           </Nav>

//           <Nav navbar>
//             {isLoggedIn && userType === 1 && (
//               <NavItem>
//                 <NavLink tag={RRNavLink} to="/admin">
//                   Admin
//                 </NavLink>
//               </NavItem>
//             )}
//           </Nav>

//           <Nav navbar>
//               <NavItem>
//                 <NavLink tag={RRNavLink} to="/discs">
//                   Discs
//                 </NavLink>
//               </NavItem>
//           </Nav>

          

//           <Nav navbar>
//             {isLoggedIn && (
//               <>
//                 <NavItem>
//                   <a
//                     aria-current="page"
//                     className="nav-link"
//                     style={{ cursor: "pointer" }}
//                     onClick={logout}
//                   >
//                     Logout
//                   </a>
//                 </NavItem>
//               </>
//             )}
//             {!isLoggedIn && (
//               <>
//                 <NavItem>
//                   <NavLink tag={RRNavLink} to="/login">
//                     Login
//                   </NavLink>
//                 </NavItem>
//                 <NavItem>
//                   <NavLink tag={RRNavLink} to="/register">
//                     Register
//                   </NavLink>
//                 </NavItem>
//               </>
//             )}
//           </Nav>

//         </Collapse>

//       </Navbar>
//     </div>
//   );
