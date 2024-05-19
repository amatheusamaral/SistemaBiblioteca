const express = require('express');
const app = express();

app.use(express.json());

app.use('/api/livros', require('./routes/livros'));
app.use('/api/emprestimos', require('./routes/emprestimos'));
app.use('/api/categorias', require('./routes/categorias'));

const PORT = process.env.PORT || 5000;
app.listen(PORT, () => console.log(`Servidor rodando na porta ${PORT}`));
