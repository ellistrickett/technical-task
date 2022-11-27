import React, { useState, useEffect } from "react";
import axios from 'axios';
import Maps from './components/Maps.js';

function App() {
  const [alertData, setAlertData] = useState();

  useEffect(() => {
    async function getData() {
      const response = await axios.get(`https://localhost:7039/api/Alerts`);
      setAlertData(response.data);
    }
    getData();
  }, []);

  return (
    <div>
      {alertData ? (
        <Maps alerts={alertData} />
      ) : (
        null
      )
      }
    </div>
  );
}

export default App;
