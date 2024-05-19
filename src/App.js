import React from 'react';
import './App.css';

import CadastroLivro from './components/CadastroLivro';
import EmprestimoLivro from './components/EmprestimoLivro';
import DevolucaoLivro from './components/DevolucaoLivro';
import ConsultaLivros from './components/ConsultaLivros';
import HistoricoEmprestimos from './components/HistoricoEmprestimos';
import Categoria from './components/Categoria';

function App() {
  return (
    <div className="App">
      <h1>Biblioteca</h1>
      <Categoria /> 
      <CadastroLivro />
      <EmprestimoLivro />
      <DevolucaoLivro />
      <ConsultaLivros />
      <HistoricoEmprestimos />
    </div>
  );
}

export default App;
