import { Box, Button, TextField, Typography } from "@mui/material";
import { useEffect, useState } from "react";
import { DataGrid, GridColDef } from "@mui/x-data-grid";
import { Usuario } from "../Interface/IUsuarios";
import axios from "axios";

export default function DataGridDemo() {
    const [rows, setRows] = useState<Usuario[]>([]);
    const [loading, setLoading] = useState(true);
    const [nombre, setNombre] = useState('');
    const [user, setUser] = useState('');
    const [password, setPassword] = useState('');
    const [fkRol, setFkRol] = useState(0);

    const columns: GridColDef[] = [
        { field: 'pkUsuario', headerName: 'ID', width: 70 },
        { field: 'nombre', headerName: 'Nombre', width: 200 },
        { field: 'user', headerName: 'Usuario', width: 130 },
    ];

    const fetchData = async () => {
        try {
            const response = await axios.get('https://localhost:7141/Usuarios');
            const data = response.data.result;
            setRows(data);
            setLoading(false); 
        } catch (error) {
            console.error('Error fetching data:', error);
            setLoading(false); 
        }
    };

    const handleCreateUser = async () => {
        const newUser = {
            nombre,
            user,
            password,
            fkRol,
        };

        try {
            await axios.post('https://localhost:7141/Usuarios', newUser);
            fetchData(); // Refresh the data after adding a new user
        } catch (error) {
            console.error('Error creating user:', error);
        }
    };

    useEffect(() => {
        fetchData();
    }, []);

    return (
        <Box>
            {loading ? ( 
                <Typography variant="h6" color="error" style={{ marginBottom: '1rem' }}>Cargando datos...</Typography>
            ) : ( 
                rows.length > 0 ? (
                    <Typography variant="h6" color="success" style={{ marginBottom: '1rem' }}>Datos cargados correctamente</Typography>
                ) : (
                    <Typography variant="h6" color="error" style={{ marginBottom: '1rem' }}>No se encontraron datos</Typography>
                )
            )}
            <Box component="form" sx={{ mb: 2 }} onSubmit={e => { e.preventDefault(); handleCreateUser(); }}>
                <TextField label="Nombre" value={nombre} onChange={e => setNombre(e.target.value)} fullWidth margin="normal" />
                <TextField label="Usuario" value={user} onChange={e => setUser(e.target.value)} fullWidth margin="normal" />
                <TextField label="Contraseña" value={password} onChange={e => setPassword(e.target.value)} type="password" fullWidth margin="normal" />
                <TextField label="Rol" value={fkRol} onChange={e => setFkRol(Number(e.target.value))} type="number" fullWidth margin="normal" />
                <Button type="submit" variant="contained" color="primary">Crear Usuario</Button>
            </Box>
            <DataGrid rows={rows} columns={columns} getRowId={(row) => row.pkUsuario} />
        </Box>
    );
}

export interface Usuario {
    pkUsuario: number;
    nombre: string;
    user: string;
    password: string;
    fkRol: number;
    roles: string;
}
