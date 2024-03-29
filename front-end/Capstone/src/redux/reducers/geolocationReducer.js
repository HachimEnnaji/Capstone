import { createSlice } from "@reduxjs/toolkit";

const initialState = {
  geolocation: {
    latitude: 0,
    longitude: 0,
  },
};

const geolocationReducer = createSlice({
  name: "geolocationReducer",
  initialState,
  reducers: {
    setGeolocation: (state, action) => {
      state.geolocation = action.payload;
    },
  },
});

export const { setGeolocation } = geolocationReducer.actions;
export default geolocationReducer.reducer;
