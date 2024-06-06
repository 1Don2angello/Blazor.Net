import { Box, Button, Typography, Paper, Dialog, DialogActions, DialogContent, DialogTitle, TextField } from "@mui/material";
import { useEffect, useState } from "react";
import { DataGrid, GridColDef } from "@mui/x-data-grid";
import { Autores } from "../Interface/IAutor";
import axios from "axios";

export default function DataGridDemo() {
    const [rows, setRows] = useState<Autores[]>([]);
    const [dataLoaded, setDataLoaded] = useState(false);
    const [loading, setLoading] = useState(true);
    const [open, setOpen] = useState(false);
    const [openConfirm, setOpenConfirm] = useState(false);
    const [openAdd, setOpenAdd] = useState(false);
    const [currentAutor, setCurrentAutor] = useState<Autores | null>(null);
    const [newAutor, setNewAutor] = useState<Autores>({ pkAutor: 0, nombre: "", nacionalidad: "" });
    const [autorToDelete, setAutorToDelete] = useState<number | null>(null);

    const columns: GridColDef[] = [
        { field: 'pkAutor', headerName: 'ID', width: 70 },
        { field: 'nombre', headerName: 'Nombre', width: 200 },
        { field: 'nacionalidad', headerName: 'Nacionalidad', width: 130 },
        {
            field: 'actions',
            headerName: 'Acciones',
            width: 150,
            renderCell: (params) => (
                <Box display="flex" justifyContent="space-between" width="100%">
                    <Button variant="contained" color="primary" size="small" onClick={() => handleEdit(params.row)}>Editar</Button>
                    <Button variant="contained" color="secondary" size="small" onClick={() => handleOpenConfirm(params.row.pkAutor)} style={{ marginLeft: 8 }}>Eliminar</Button>
                </Box>
            ),
        },
    ];

    const fetchData = async () => {
        try {
            const response = await axios.get('https://localhost:7140/api/Autor');
            const data = response.data.result; // Accessing the 'result' field from the response
            setRows(data);
            setLoading(false);
        } catch (error) {
            console.error('Error fetching data:', error);
            setLoading(false); // Set loading to false even if there's an error
        }
    };

    const handleDelete = async () => {
        if (autorToDelete !== null) {
            try {
                await axios.delete(`https://localhost:7140/Eliminar/${autorToDelete}`);
                setRows((prevRows) => prevRows.filter((row) => row.pkAutor !== autorToDelete));
                setAutorToDelete(null);
                handleCloseConfirm();
            } catch (error) {
                console.error('Error deleting data:', error);
            }
        }
    };

    const handleEdit = (autor: Autores) => {
        setCurrentAutor(autor);
        setOpen(true);
    };
    
    const handleOpenConfirm = (pkAutor: number) => {
        setAutorToDelete(pkAutor);
        setOpenConfirm(true);
    };
    

    const handleCloseConfirm = () => {
        setOpenConfirm(false);
        setAutorToDelete(null);
    };

    const handleClose = () => {
        setOpen(false);
        setCurrentAutor(null);
    };

    const handleOpenAdd = () => {
        setOpenAdd(true);
    };

    const handleCloseAdd = () => {
        setOpenAdd(false);
        setNewAutor({ pkAutor: 0, nombre: "", nacionalidad: "" });
    };

    const handleSave = async () => {
        try {
            await axios.put(`https://localhost:7140/api/Autor/${currentAutor.pkAutor}`, currentAutor);
            setRows((prevRows) => prevRows.map((row) => (row.pkAutor === currentAutor.pkAutor ? currentAutor : row)));
            handleClose();
        } catch (error) {
            console.error('Error updating data:', error);
        }
    };

    const handleAdd = async () => {
        try {
            const response = await axios.post('https://localhost:7140/api/Autor', newAutor);
            setRows((prevRows) => [...prevRows, response.data]);
            handleCloseAdd();
        } catch (error) {
            console.error('Error adding data:', error);
        }
    };

    useEffect(() => {
        fetchData();
    }, []);

    useEffect(() => {
        if (rows.length > 0) {
            setDataLoaded(true);
            console.log("Cargado Correctamente");
        } else {
            console.log('No cargado');
        }
    }, [rows]);

    return (
        <Box sx={{ padding: '2rem', backgroundColor: '#f5f5f5', minHeight: '100vh' }}>
            <Paper sx={{ padding: '2rem', backgroundColor: '#fff', boxShadow: 3 }}>
                {loading ? (
                    <Typography variant="h6" color="error" sx={{ marginBottom: '1rem' }}>Cargando datos...</Typography>
                ) : (
                    dataLoaded && (
                        <Typography variant="h6" color="success" sx={{ marginBottom: '1rem' }}>Datos cargados correctamente</Typography>
                    )
                )}
                <Button variant="contained" color="primary" sx={{ marginBottom: '1rem' }} onClick={handleOpenAdd}>
                    Agregar Autor
                </Button>
                <DataGrid
                    rows={rows}
                    columns={columns}
                    getRowId={(row) => row.pkAutor}
                    autoHeight
                    sx={{
                        '& .MuiDataGrid-root': {
                            border: 'none',
                        },
                        '& .MuiDataGrid-cell': {
                            borderBottom: '1px solid #e0e0e0',
                        },
                        '& .MuiDataGrid-columnHeaders': {
                            backgroundColor: '#e0e0e0',
                            borderBottom: '1px solid #e0e0e0',
                        },
                        '& .MuiDataGrid-columnHeaderTitle': {
                            fontWeight: 'bold',
                            color: '#333',
                        },
                        '& .MuiDataGrid-row': {
                            '&:nth-of-type(odd)': {
                                backgroundColor: '#fafafa',
                            },
                        },
                        '& .MuiDataGrid-footerContainer': {
                            justifyContent: 'center',
                            padding: '1rem',
                            backgroundColor: '#e0e0e0',
                            borderTop: '1px solid #e0e0e0',
                        },
                    }}
                />
            </Paper>
            <Dialog open={open} onClose={handleClose}>
                <DialogTitle>Editar Autor</DialogTitle>
                <DialogContent>
                    <TextField
                        margin="dense"
                        label="Nombre"
                        type="text"
                        fullWidth
                        variant="outlined"
                        value={currentAutor?.nombre || ''}
                        onChange={(e) => setCurrentAutor({ ...currentAutor, nombre: e.target.value })}
                    />
                    <TextField
                        margin="dense"
                        label="Nacionalidad"
                        type="text"
                        fullWidth
                        variant="outlined"
                        value={currentAutor?.nacionalidad || ''}
                        onChange={(e) => setCurrentAutor({ ...currentAutor, nacionalidad: e.target.value })}
                    />
                </DialogContent>
                <DialogActions>
                    <Button onClick={handleClose} color="primary">
                        Cancelar
                    </Button>
                    <Button onClick={handleSave} color="primary">
                        Guardar
                    </Button>
                </DialogActions>
            </Dialog>
            <Dialog open={openConfirm} onClose={handleCloseConfirm}>
                <DialogTitle>Confirmar Eliminación</DialogTitle>
                <DialogContent>
                    <Typography>¿Estás seguro de que deseas eliminar este autor?</Typography>
                </DialogContent>
                <DialogActions>
                    <Button onClick={handleCloseConfirm} color="primary">
                        Cancelar
                    </Button>
                    <Button onClick={handleDelete} color="secondary">
                        Eliminar
                    </Button>
                </DialogActions>
            </Dialog>
            <Dialog open={openAdd} onClose={handleCloseAdd}>
                <DialogTitle>Agregar Autor</DialogTitle>
                <DialogContent>
                    <TextField
                        margin="dense"
                        label="Nombre"
                        type="text"
                        fullWidth
                        variant="outlined"
                        value={newAutor.nombre}
                        onChange={(e) => setNewAutor({ ...newAutor, nombre: e.target.value })}
                    />
                    <TextField
                        margin="dense"
                        label="Nacionalidad"
                        type="text"
                        fullWidth
                        variant="outlined"
                        value={newAutor.nacionalidad}
                        onChange={(e) => setNewAutor({ ...newAutor, nacionalidad: e.target.value })}
                    />
                </DialogContent>
                <DialogActions>
                    <Button onClick={handleCloseAdd} color="primary">
                        Cancelar
                    </Button>
                    <Button onClick={handleAdd} color="primary">
                        Agregar
                    </Button>
                </DialogActions>
            </Dialog>
        </Box>
    );
}
