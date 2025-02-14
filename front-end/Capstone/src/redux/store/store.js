import { combineReducers, configureStore } from "@reduxjs/toolkit";
import { persistStore, persistReducer } from "redux-persist";
import storage from "redux-persist/lib/storage";
import expireReducer from "redux-persist-expire";
import authReducer from "../reducers/authReducer";
import geolocationReducer from "../reducers/geolocationReducer";

const persistConfig = {
  key: "root",
  storage,
  whitelist: ["auth"],
  transforms: [
    expireReducer("auth", {
      expireSeconds: 7 * 24 * 60 * 60, // 7 days
      expiredState: { loggedProfile: null },
      autoExpire: true,
    }),
  ],
};

const rootReducer = combineReducers({
  auth: authReducer,
  geolocation: geolocationReducer,
});

const persistedReducer = persistReducer(persistConfig, rootReducer);

export const store = configureStore({
  reducer: persistedReducer,
  middleware: (getDefaultMiddleware) => getDefaultMiddleware({ serializableCheck: false }),
});

export const persistor = persistStore(store);
