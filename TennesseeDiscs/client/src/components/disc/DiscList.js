import React, { useEffect, useState } from "react";
import { getAllDiscs } from "../../modules/discManager";
import "./Disc.css";
import { useNavigate } from "react-router-dom";
import { DiscCard } from "./DiscCard";

export const DiscList = () => {
    const [discs, setDiscs] = useState([])

    const getDiscs = () => {
        getAllDiscs().then(discs => setDiscs(discs));
    }

    const navigate = useNavigate();

    
    useEffect(() => {
        getDiscs();
    }, [])
    
    //do func to check type of user, if they are admin, do a ternary below for "Add Disc";
    return (
        <>            
            <section className="add-disc-container"> 
                <h2>All Discs</h2>
                <button type="button"
                    className={discs.length > 0 ? 'add-disc-button' : 'addDiscButton'}
                    onClick={() => {navigate("/discs/create")}}>
                        Add Disc
                    </button>
            </section>

            <div className="disc-list">
                {discs.map(disc =>
                    <DiscCard
                        key={disc.id}  //unique key for React to keep track of items and to re-render only things that have changed. 
                        disc={disc}    //pass the disc object and its properties to child component (discCard) 
                        // handleDeleteDisc={handleDeleteDisc} //pass the delete func to child comp for the card's delete button. 
                    />)}
            </div>
        </>
    )

}