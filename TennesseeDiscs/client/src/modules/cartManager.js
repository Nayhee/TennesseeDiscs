const baseUrl = '/api/Cart';

export const getCartById = (cartId) => {
    return fetch(`${baseUrl}/${cartId}`)
    .then(res => res.json())
}

export const addCart = (cart) => {
    return fetch(baseUrl, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(cart),
    });
  };

  export const deleteCart = (id) => {
    return fetch(`${baseUrl}/${id}`, {
        method: "DELETE"
    }).then(result => result.json())
}



const cartDiscUrl = '/api/CartDisc';

//removed the 3 inputs, maybe I just build the cartDisc object beforehand then send it. 
export const addDiscToCart = (cartDisc) => {
    return fetch(cartDiscUrl, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(cartDisc),
    });
  };

  export const deleteCartDisc = (id) => {
    return fetch(`${cartDiscUrl}/${id}`, {
        method: "DELETE"
    }).then(result => result.json())
}