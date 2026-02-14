import { useState } from "react";
import { api } from "../api/api";

export function ProdutoForm() {
  const [nome, setNome] = useState("");
  const [codigo, setCodigo] = useState("");

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      await api.post("/produtos", { nome, codigo }); // Ajuste rota
      setNome("");
      setCodigo("");
      alert("Produto criado!");
    } catch (err) {
      console.error(err);
      alert("Erro ao criar produto");
    }
  };

  return (
    <form onSubmit={handleSubmit}>
      <input
        placeholder="Nome"
        value={nome}
        onChange={(e) => setNome(e.target.value)}
      />
      <input
        placeholder="Código"
        value={codigo}
        onChange={(e) => setCodigo(e.target.value)}
      />
      <button type="submit">Adicionar</button>
    </form>
  );
}
