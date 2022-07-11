import React from "react"
import "./Disc.css"
import { Link } from "react-router-dom";


export const DiscCard = ({ disc }) => {
    return (
      <div className="card-disc">
        <div className="card-disc-content">

          <div className="image_div">
              <img src={disc.ImageUrl} alt="My Disc" />
          </div>

            <div class="flightNumsContainer">
                    <div class="flightNum">{disc.Speed}</div>
                    <div class="flightNum">{disc.Glide}</div>
                    <div class="flightNum">{disc.Turn}</div>
                    <div class="flightNum">{disc.Fade}</div>
            </div>

          <h2><span className="card-disc-name">
            {disc.NamePlastic}
          </span></h2>
          
          <div className="DetailsButtonsContainer">
            <Link to={`/discs/${disc.id}/details`}>
                <button>Details</button>
            </Link>
          </div>

        </div>
      </div>
    );
  }