const express = require("express");
const cors = require("cors");
const axios = require("axios");

const app = express();
app.use(express.json());
app.use(cors({ origin: true }));

app.post("/authenticate", async (req, res) => {
  const { username } = req.body; 
  try {
    const r = await axios.put(
      'https://api.chatengine.io/users/',
      { username: username, secret: username, first_name: username },
      {
        headers: {
          "private-key": "d0c6ad2a-96b7-4ec2-a2d9-af1c3f0e2308",
        },
      }
    );

    // Check if 'r' is defined
    if (r) {
      // Check if 'r' has the expected properties
      if (r.status !== undefined && r.data !== undefined) {
        return res.status(r.status).json(r.data);
      } else {
        console.error("Unexpected response format - Missing 'status' or 'data':", r);
        return res.status(500).json({ error: "Internal Server Error" });
      }
    } else {
      console.error("Unexpected response format - 'r' is undefined:", r);
      return res.status(500).json({ error: "Internal Server Error" });
    }
  } catch (e) {
    if (e.response) {
      return res.status(e.response.status).json(e.response.data);
    } else {
      console.error("Error making request:", e.message);
      return res.status(500).json({ error: "Internal Server Error" });
    }
  }
});

app.listen(3002, () => {
  console.log("Server is running on port 3002");
});
