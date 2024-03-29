import { setLoggedProfile } from "../reducers/authReducer";
const url = "https://localhost:7061/";

// auth/login endpoint
export const loginPost = (loginObj) => async (dispatch) => {
  try {
    const response = await fetch(url + "auth/login", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(loginObj),
    });

    if (response.ok) {
      const dataProfile = await response.json();
      console.log(dataProfile);

      dispatch(setLoggedProfile(dataProfile));
    } else {
      throw new Error("Errore nel recupero dei risultati");
    }
  } catch (error) {
    // Puoi gestire gli errori qui, se necessario
    console.error("Errore nel fetch:", error.message);
  } finally {
    console.log("finally");
  }
};
// auth/register endpoint
export const registerPost = (registerObj) => async (dispatch) => {
  try {
    const response = await fetch(url + "auth/register", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(registerObj),
    });

    if (response.ok) {
      const loginObj = {
        email: registerObj.email,
        password: registerObj.password,
      };

      dispatch(loginPost(loginObj));
    } else {
      if (response.status === 409) {
        console.log("email già presente");
      } else {
        throw new Error("Errore nel recupero dei risultati");
      }
    }
  } catch (error) {
    // Puoi gestire gli errori qui, se necessario
    console.error("Errore nel fetch:", error.message);
  } finally {
    console.log("finally");
  }
};
