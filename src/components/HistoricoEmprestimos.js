import React, { useState, useEffect } from 'react';
import axios from 'axios';

function HistoricoEmprestimos() {
  const [historico, setHistorico] = useState([]);

  useEffect(() => {
    axios.get('http://localhost:3001/api/routes/emprestimo') 
      .then(response => {
        setHistorico(response.data);
      })
      .catch(error => {
        console.error('Erro ao obter histórico de empréstimos:', error);
      });
  }, []);

  return (
    <div>
      <h2>Histórico de Empréstimos</h2>
      <ul>
        {historico.map((emprestimo, index) => (
          <li key={index}>{emprestimo.usuario} emprestou "{emprestimo.livro}" em {emprestimo.data}</li>
        ))}
      </ul>
    </div>
  );
}

export default HistoricoEmprestimos;
