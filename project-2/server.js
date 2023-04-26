const express = require('express');
const connectDB = require('./config/db');

const app = express();

// Connect DataBase
connectDB();

// Init Middleware
app.use(express.json());

app.get('/', (req, res) => res.json({ msg: 'Hello World!' }));

// Define Routes
app.use('/api/auth', require('./routes/auth'));
app.use('/api/users', require('./routes/users'));
app.use('/api/contacts', require('./routes/contacts'));

const PORT = process.env.PORT || 4000;

app.listen(PORT, () => console.log(`Server started on port ${PORT}`));
