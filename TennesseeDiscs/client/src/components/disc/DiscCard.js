import React from "react"
import "./Disc.css"
import { Link } from "react-router-dom";


export const DiscCard = ({ disc }) => {
    return (
      <div className="card-disc">
        <div className="card-disc-content">

          <div className="image_div">
              <img src={disc.imageUrl} alt="My Disc" />
          </div>

            <div className="flightNumsContainer">
                    <div className="flightNum">{disc.Speed}</div>
                    <div className="flightNum">{disc.Glide}</div>
                    <div className="flightNum">{disc.Turn}</div>
                    <div className="flightNum">{disc.Fade}</div>
            </div>

          <h2><span className="card-disc-name">
            {disc.NamePlastic}
          </span></h2>
          
          <div className="DetailsButtonsContainer">
            <Link to={`discs/${disc.id}`}>
                <button>Details</button>
            </Link>
          </div>

        </div>
      </div>
    );
  }