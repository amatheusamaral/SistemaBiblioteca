import React, { useState, useEffect } from 'react';
import axios from 'axios';

function ConsultaLivros() {
  const [livrosDisponiveis, setLivrosDisponiveis] = useState([]);

  useEffect(() => {
    axios.get('http://localhost:3001/api/routes/livros')
      .then(response => {
        setLivrosDisponiveis(response.data);
      })
      .catch(error => {
        console.error('Erro ao obter livros disponíveis:', error);
      });
  }, []);

  return (
    <div>
      <h2>Consulta de Livros Disponíveis</h2>
      <ul>
        {livrosDisponiveis.map((livro, index) => (
          <li key={index}>{livro.titulo}</li>
        ))}
      </ul>
    </div>
  );
}

export default ConsultaLivros;
