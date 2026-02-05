import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Pickaxe, Package, Truck, Ship, Plus, MapPin, Scale, RefreshCcw } from 'lucide-react';

const API_URL = 'https://localhost:7000/api/LotesMinerio'; // Ajuste a porta se necessário

export default function App() {
  const [lotes, setLotes] = useState([]);
  const [loading, setLoading] = useState(true);
  
  // Estado do formulário
  const [formData, setFormData] = useState({
    codigoLote: '',
    minaOrigem: '',
    teorFe: 65,
    umidade: 5,
    toneladas: 0,
    status: 0,
    localizacaoAtual: '',
    siO2: null,
    p: null
  });

  const carregarLotes = async () => {
    try {
      setLoading(true);
      const res = await axios.get(API_URL);
      setLotes(res.data);
    } catch (err) {
      console.error("Erro ao carregar lotes:", err);
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => { carregarLotes(); }, []);

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      await axios.post(API_URL, formData);
      alert("Lote cadastrado com sucesso!");
      carregarLotes(); // Atualiza a lista
    } catch (err) {
      alert(err.response?.data || "Erro ao conectar com a API");
    }
  };

  const renderStatus = (status) => {
    const config = {
      0: { label: 'Estoque', css: 'bg-blue-100 text-blue-700', icon: <Package size={14}/> },
      1: { label: 'Transporte', css: 'bg-amber-100 text-amber-700', icon: <Truck size={14}/> },
      2: { label: 'Embarcado', css: 'bg-emerald-100 text-emerald-700', icon: <Ship size={14}/> }
    };
    const item = config[status];
    return (
      <span className={`flex items-center gap-1.5 px-3 py-1 rounded-full text-xs font-bold ${item.css}`}>
        {item.icon} {item.label}
      </span>
    );
  };

  return (
    <div className="min-h-screen bg-slate-50 p-6 font-sans text-slate-900">
      <div className="max-w-6xl mx-auto">
        
        {/* Header */}
        <header className="flex justify-between items-center mb-8 bg-white p-6 rounded-2xl shadow-sm border border-slate-200">
          <div>
            <h1 className="text-2xl font-black tracking-tight flex items-center gap-2">
              <Pickaxe className="text-orange-500" /> CONTROLE FERROVIÁRIO
            </h1>
            <p className="text-slate-500 text-sm">Monitoramento de Lotes de Minério</p>
          </div>
          <button onClick={carregarLotes} className="p-2 hover:bg-slate-100 rounded-full transition">
            <RefreshCcw size={20} className={loading ? 'animate-spin' : ''} />
          </button>
        </header>

        <div className="grid grid-cols-1 lg:grid-cols-3 gap-8">
          
          {/* Formulário */}
          <section className="bg-white p-6 rounded-2xl shadow-sm border border-slate-200 h-fit">
            <h2 className="text-lg font-bold mb-6 flex items-center gap-2">
              <Plus className="text-blue-600" size={20}/> Novo Registro
            </h2>
            <form onSubmit={handleSubmit} className="space-y-4">
              <div>
                <label className="text-xs font-bold text-slate-400 uppercase">Dados Básicos</label>
                <input placeholder="Código do Lote" className="w-full border p-2.5 rounded-lg mt-1" 
                  onChange={e => setFormData({...formData, codigoLote: e.target.value})} required />
                <input placeholder="Mina de Origem" className="w-full border p-2.5 rounded-lg mt-2" 
                  onChange={e => setFormData({...formData, minaOrigem: e.target.value})} required />
              </div>

              <div className="grid grid-cols-2 gap-3">
                <div>
                  <label className="text-[10px] font-bold text-slate-400 uppercase">Teor Fe %</label>
                  <input type="number" step="0.01" value={formData.teorFe} className="w-full border p-2 rounded-lg" 
                    onChange={e => setFormData({...formData, teorFe: parseFloat(e.target.value)})} />
                </div>
                <div>
                  <label className="text-[10px] font-bold text-slate-400 uppercase">Toneladas</label>
                  <input type="number" className="w-full border p-2 rounded-lg" 
                    onChange={e => setFormData({...formData, toneladas: parseFloat(e.target.value)})} required />
                </div>
              </div>

              <div>
                <label className="text-xs font-bold text-slate-400 uppercase">Logística</label>
                <input placeholder="Localização Atual" className="w-full border p-2.5 rounded-lg mt-1" 
                  onChange={e => setFormData({...formData, localizacaoAtual: e.target.value})} required />
                <select className="w-full border p-2.5 rounded-lg mt-2 bg-white" 
                  onChange={e => setFormData({...formData, status: parseInt(e.target.value)})}>
                  <option value="0">Em Estoque</option>
                  <option value="1">Em Transporte</option>
                  <option value="2">Embarcado</option>
                </select>
              </div>

              <button type="submit" className="w-full bg-slate-900 text-white font-bold py-3 rounded-xl hover:bg-slate-800 transition">
                Salvar Lote
              </button>
            </form>
          </section>

          {/* Tabela */}
          <section className="lg:col-span-2 bg-white rounded-2xl shadow-sm border border-slate-200 overflow-hidden">
            <table className="w-full text-left border-collapse">
              <thead className="bg-slate-50 border-b border-slate-200 text-slate-500 text-xs uppercase font-bold">
                <tr>
                  <th className="px-6 py-4">Lote / Mina</th>
                  <th className="px-6 py-4 text-center">Qualidade</th>
                  <th className="px-6 py-4">Status / Local</th>
                </tr>
              </thead>
              <tbody className="divide-y divide-slate-100">
                {lotes.map(lote => (
                  <tr key={lote.id} className="hover:bg-slate-50/50 transition">
                    <td className="px-6 py-4">
                      <div className="font-bold text-slate-800">{lote.codigoLote}</div>
                      <div className="text-xs text-slate-500 italic">{lote.minaOrigem}</div>
                    </td>
                    <td className="px-6 py-4">
                      <div className="flex flex-col items-center">
                        <span className="flex items-center gap-1 text-orange-600 font-bold"><Scale size={14}/> {lote.teorFe}% Fe</span>
                        <span className="text-[10px] text-slate-400">{lote.toneladas.toLocaleString()} toneladas</span>
                      </div>
                    </td>
                    <td className="px-6 py-4">
                      <div className="flex flex-col gap-1.5">
                        {renderStatus(lote.status)}
                        <span className="text-[10px] flex items-center gap-1 text-slate-400">
                          <MapPin size={10}/> {lote.localizacaoAtual}
                        </span>
                      </div>
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>
          </section>
        </div>
      </div>
    </div>
  );
}