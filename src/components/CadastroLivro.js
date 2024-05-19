import React, { useState } from 'react';
import axios from 'axios'; // Importe o Axios

function CadastroLivro() {
  const [livros, setLivros] = useState([]);
  const [titulo, setTitulo] = useState('');
  const [autor, setAutor] = useState('');
  const [categoria, setCategoria] = useState('');

  const adicionarLivro = () => {
    const novoLivro = { titulo, autor, categoria };
    
    axios.post('http://localhost:3001/api/livros', novoLivro)
      .then(response => {
        console.log('Livro adicionado com sucesso:', response.data);
        setLivros([...livros, response.data]); 
        setTitulo('');
        setAutor('');
        setCategoria('');
      })
      .catch(error => {
        console.error('Erro ao adicionar livro:', error);
      });
  };

  return (
    <div>
      <h2>Cadastro de Livros</h2>
      <input type="text" placeholder="Título" value={titulo} onChange={(e) => setTitulo(e.target.value)} />
      <input type="text" placeholder="Autor" value={autor} onChange={(e) => setAutor(e.target.value)} />
      <input type="text" placeholder="Categoria" value={categoria} onChange={(e) => setCategoria(e.target.value)} />
      <button onClick={adicionarLivro}>Adicionar Livro</button>
      <ul>
        {livros.map((livro, index) => (
          <li key={index}>
            {livro.titulo} - {livro.autor} - {livro.categoria}
          </li>
        ))}
      </ul>
    </div>
  );
}

export default CadastroLivro;
