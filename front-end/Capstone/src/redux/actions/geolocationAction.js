import { setGeolocation } from "../reducers/geolocationReducer";

export const position = (adress) => async (dispatch) => {
  try {
    const response = await fetch(`https://nominatim.openstreetmap.org/search?format=json&q=${adress}`);
    if (response.ok) {
      const data = await response.json();
      console.log(data);
      dispatch(setGeolocation({ lat: data[0].lat, lon: data[0].lon }));
      return data[0];
    } else {
      throw new Error("Errore nel recupero delle coordinate");
    }
  } catch (error) {
    console.error("Errore nel fetch:", error.message);
  } finally {
    console.log("finally");
  }
};
