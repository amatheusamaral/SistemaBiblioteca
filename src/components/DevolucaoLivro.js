import React, { useState } from 'react';
import axios from 'axios'; 

function DevolucaoLivro() {
  const [livrosDevolvidos, setLivrosDevolvidos] = useState('');

  const devolverLivros = () => {
    if (livrosDevolvidos.trim() !== '') {
      axios.post('http://localhost:3001/api/routes/emprestimos', { id: parseInt(livrosDevolvidos) })
        .then(response => {
          console.log('Livro devolvido com sucesso:', response.data);
         
          setLivrosDevolvidos('');
        })
        .catch(error => {
          console.error('Erro ao devolver livro:', error);
        });
    }
  };

  return (
    <div>
      <h2>Devolução de Livros</h2>
      <input type="text" placeholder="ID do Livro Devolvido" value={livrosDevolvidos} onChange={(e) => setLivrosDevolvidos(e.target.value)} />
      <button onClick={devolverLivros}>Devolver Livro</button>
    </div>
  );
}

export default DevolucaoLivro;
