// Categoria.js

import React, { useState, useEffect } from 'react';
import axios from 'axios'; // Importe o axios para fazer requisições HTTP

function Categoria() {
  const [categorias, setCategorias] = useState([]);
  const [novaCategoria, setNovaCategoria] = useState('');

  useEffect(() => {
    axios.get('http://localhost:3001/api/routes/categorias') 
      .then(response => {
        setCategorias(response.data);
      })
      .catch(error => {
        console.error('Erro ao carregar categorias:', error);
      });
  }, []);

  const adicionarCategoria = () => {
    if (novaCategoria.trim() !== '') {
      axios.post('http://localhost:3001/api//routes/categorias', { nome: novaCategoria }) 
        .then(response => {
          setCategorias([...categorias, response.data]);
          setNovaCategoria('');
        })
        .catch(error => {
          console.error('Erro ao adicionar categoria:', error);
        });
    }
  };

  return (
    <div>
      <h2>Categorias</h2>
      <ul>
        {categorias.map((categoria, index) => (
          <li key={index}>{categoria.nome}</li>
        ))}
      </ul>
      <input type="text" value={novaCategoria} onChange={(e) => setNovaCategoria(e.target.value)} />
      <button onClick={adicionarCategoria}>Adicionar Categoria</button>
    </div>
  );
}

export default Categoria;
