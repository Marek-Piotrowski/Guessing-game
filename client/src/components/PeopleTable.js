import * as React from "react";
import Table from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import TableCell from "@mui/material/TableCell";
import TableContainer from "@mui/material/TableContainer";
import TableHead from "@mui/material/TableHead";
import TableRow from "@mui/material/TableRow";
import Paper from "@mui/material/Paper";
import { useEffect, useState } from "react";
import axios from "axios";
import { CreatePerson } from "./CreatePerson";
import DetailsIcon from "@mui/icons-material/Details";
import DeleteIcon from "@mui/icons-material/Delete";
import AddIcon from "@mui/icons-material/Add";
import Box from "@mui/material/Box";
import Modal from "@mui/material/Modal";
import Button from "@mui/material/Button";
import { Typography } from "@mui/material";
import { ToastContainer, toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import ArrowDropDownIcon from "@mui/icons-material/ArrowDropDown";
import ArrowDropUpIcon from "@mui/icons-material/ArrowDropUp";
import { Triangle } from "react-loader-spinner";

export default function PeopleTable() {
  const [data, setData] = useState([]);
  const [loading, setLoading] = useState(false);

  const [deleteStatus, setDeleteStatus] = useState(0);
  const [person, setPerson] = useState({
    name: "",
    city: "",
    language: "",
    phone: "",
  });
  const [openAddModal, setOpenAddModal] = useState(false);
  const [openDetailsModal, setOpenDetailsModal] = useState(false);

  const notify = () => toast.info(`Person deleted`);

  const handleOpenAdd = () => {
    setOpenAddModal(true);
  };
  const handleCloseAdd = () => {
    setOpenAddModal(false);
  };

  const handleOpenDetails = () => {
    setOpenDetailsModal(true);
  };
  const handleCloseDetails = () => {
    setOpenDetailsModal(false);
  };

  const handleModal = (id) => {
    handleOpenDetails();
    handleDetails(id);
  };

  const handleAddPerson = () => {
    handleOpenAdd();
  };

  const style = {
    position: "absolute",
    top: "50%",
    left: "50%",
    transform: "translate(-50%, -50%)",
    width: 400,
    bgcolor: "background.paper",
    border: "2px solid #000",
    boxShadow: 24,
    pt: 2,
    px: 4,
    pb: 3,
  };

  const handleDelete = async (id) => {
    const urlDelete = `http://localhost:25586/ReactPeople/delete/${id}`;

    await axios
      .get(urlDelete)
      .then((res) => setDeleteStatus(res.status))
      .catch((error) => console.log(error));

    setData(data.filter((person) => person.personId !== id));
    notify();
  };

  const handleDetails = (id) => {
    const url = `http://localhost:25586/ReactPeople/${id}`;

    axios
      .get(url)
      .then((res) => setPerson(res.data))
      .catch((error) => console.log(error));
  };

  const fetchUsers = async () => {
    const url = "http://localhost:25586/ReactPeople";

    await axios
      .get(url)
      .then((res) => setData(res.data))
      .catch((error) => console.log(error));
  };

  // sorting

  const handleSortDesc = () => {
    const sortedData = [...data].sort((a, b) => {
      return a.name > b.name ? 1 : -1;
    });

    setData(sortedData);
  };

  const handleSortAsc = () => {
    const sortedData = [...data].sort((a, b) => {
      return a.name < b.name ? 1 : -1;
    });

    setData(sortedData);
  };

  if (loading) {
    <Triangle ariaLabel="loading-indicator" />;
  }

  useEffect(() => {
    setLoading(true);
    fetchUsers();
    setLoading(false);
  }, [person, deleteStatus]);

  return (
    <TableContainer component={Paper}>
      <Button onClick={handleAddPerson}>
        <AddIcon />
        <Typography variant="h6" component="h2">
          Add new person
        </Typography>
      </Button>

      <Modal
        open={openAddModal}
        onClose={handleCloseAdd}
        aria-labelledby="modal-modal-title"
        aria-describedby="modal-modal-description"
      >
        <Box sx={style}>
          <CreatePerson
            fetchUsers={fetchUsers}
            handleCloseAdd={handleCloseAdd}
          />
        </Box>
      </Modal>

      <Table sx={{ minWidth: 650 }} aria-label="simple table">
        <TableHead>
          <TableRow>
            <TableCell>Id</TableCell>
            <TableCell align="right">
              <Button onClick={handleSortDesc}>
                <ArrowDropDownIcon />
              </Button>
              Name
              <Button onClick={handleSortAsc}>
                <ArrowDropUpIcon />
              </Button>
            </TableCell>
            <TableCell align="right">Details</TableCell>
            <TableCell align="right">Delete</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {data.map((item) => (
            <TableRow
              key={item.personId}
              sx={{ "&:last-child td, &:last-child th": { border: 0 } }}
            >
              <TableCell component="th" scope="row">
                {item.personId}
              </TableCell>
              <TableCell align="right">{item.name}</TableCell>
              <TableCell align="right">
                <Button onClick={() => handleModal(item.personId)}>
                  <DetailsIcon />
                </Button>

                <Modal
                  open={openDetailsModal}
                  onClose={handleCloseDetails}
                  aria-labelledby="modal-modal-title"
                  aria-describedby="modal-modal-description"
                >
                  <Box sx={style}>
                    <Typography
                      id="modal-modal-title"
                      variant="h4"
                      component="h2"
                    >
                      {person.name} Details:
                    </Typography>
                    <Typography sx={{ mt: 2 }}>Name: {person.name}</Typography>
                    <Typography sx={{ mt: 2 }}>
                      Phone number: {person.phone}
                    </Typography>
                    <Typography sx={{ mt: 2 }}>City: {person.city}</Typography>
                    <Typography sx={{ mt: 2 }}>
                      Language: {person.language}
                    </Typography>
                  </Box>
                </Modal>
                {/* {<Details id={item.personId} />} */}
              </TableCell>
              <TableCell align="right">
                <Button onClick={() => handleDelete(item.personId)}>
                  <DeleteIcon />
                </Button>
              </TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
      <ToastContainer position="bottom-right" />
    </TableContainer>
  );
}
