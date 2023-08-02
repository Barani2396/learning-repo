import {
  GET_LOGS,
  ADD_LOG,
  DELETE_LOG,
  SET_LOADING,
  LOGS_ERROR,
  SET_CURRENT,
  CLEAR_CURRENT,
  UPDATE_LOG,
  SEARCH_LOGS,
} from './types';

// export const getLogs = () => {
//   return async (dispatch) => {
//     setLoading();
//     const res = await fetch('/logs');
//     const data = await res.json();

//     dispatch({ type: GET_LOGS, payload: data });
//   };
// };

// Get logs from server
export const getLogs = () => async (dispatch) => {
  try {
    setLoading();
    const res = await fetch('/logs');
    const data = await res.json();

    dispatch({ type: GET_LOGS, payload: data });
  } catch (err) {
    dispatch({ type: LOGS_ERROR, payload: err.response.statusText });
  }
};

// Add a log
export const addLog = (log) => async (dispatch) => {
  try {
    setLoading();
    const res = await fetch('/logs', {
      method: 'post',
      body: JSON.stringify(log),
      headers: {
        'Content-Type': 'application/json',
      },
    });
    const data = await res.json();

    dispatch({ type: ADD_LOG, payload: data });
  } catch (err) {
    dispatch({ type: LOGS_ERROR, payload: err.response.statusText });
  }
};

// Delete log from server
export const deleteLog = (id) => async (dispatch) => {
  try {
    setLoading();
    await fetch(`/logs/${id}`, {
      method: 'delete',
    });

    dispatch({ type: DELETE_LOG, payload: id });
  } catch (err) {
    dispatch({ type: LOGS_ERROR, payload: err.response.statusText });
  }
};

// Update log from server
export const updateLog = (log) => async (dispatch) => {
  try {
    const res = await fetch(`/logs/${log.id}`, {
      method: 'put',
      body: JSON.stringify(log),
      headers: {
        'Content-Type': 'application/json',
      },
    });

    const data = await res.json();

    dispatch({ type: UPDATE_LOG, payload: data });
  } catch (err) {
    dispatch({ type: LOGS_ERROR, payload: err.response.statusText });
  }
};

// Search logs from server
export const searchLogs = (text) => async (dispatch) => {
  try {
    const res = await fetch(`/logs?q=${text}`);
    const data = await res.json();

    dispatch({ type: SEARCH_LOGS, payload: data });
  } catch (err) {
    dispatch({ type: LOGS_ERROR, payload: err.response.statusText });
  }
};

// Set current
export const setCurrent = (log) => {
  return {
    type: SET_CURRENT,
    payload: log,
  };
};

// Clear current
export const clearCurrent = (log) => {
  return {
    type: CLEAR_CURRENT,
  };
};

// Set loading
export const setLoading = () => {
  return {
    type: SET_LOADING,
  };
};
