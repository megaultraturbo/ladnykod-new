import { ActionTypes } from "@mui/base";
import { act } from "react-dom/test-utils";
import api from "./api";

export const ACTION_TYPES = {
  CREATE: "CREATE",
  UPDATE: "UPDATE",
  DELETE: "DELETE",
  FETCH_ALL: "FETCH_ALL",
};

const formateDate = (data) => ({
  ...data,
  pagesNumber: parseInt(data.pagesNumber ? data.pagesNumber : 0),
});

export const fetchAllBooks = () => (dispatch) => {
  try {
    api
      .Book()
      .fetchAll()
      .then((response) => {
        dispatch({
          type: ACTION_TYPES.FETCH_ALL,
          payload: response.data,
        });
      });
  } catch (err) {
    console.log(err);
  }
};

export const createBook = (data, onSuccess) => (dispatch) => {
  try {
    api
      .Book()
      .create(data)
      .then((res) => {
        dispatch({
          type: ACTION_TYPES.CREATE,
          payload: res.data,
        });
        onSuccess();
      });
  } catch (err) {
    console.log(err);
  }
};

export const update = (id, data, onSuccess) => (dispatch) => {
  data = formateDate(data);
  api
    .Book()
    .update(id, data)
    .then((res) => {
      dispatch({
        type: ACTION_TYPES.UPDATE,
        payload: { id, ...data },
      });
      onSuccess();
    })
    .catch((err) => console.log(err));
};

export const deleteBook = (id, data, onSuccess) => (dispatch) => {
  api
    .Book()
    .delete(id)
    .then((res) => {
      dispatch({
        type: ACTION_TYPES.DELETE,
        payload: id,
      });
      onSuccess();
    })
    .catch((err) => console.log(err));
};
