import { CheckCircle, Plus, XCircle } from 'phosphor-react';
import React, { useEffect, useState } from 'react'
import { Button, Modal } from 'react-bootstrap';
import api from "../../api/movierent";
import TitlePage from '../../components/TitlePage';
import RentList from "./RentList";
import RentForm from "./RentForm";

function Rent() {
  const [showRentModal, setShowRentModal] = useState(false);
  const [smshowConfirmModal, setSmshowConfirmModal] = useState(false);
  const [rents, setRents] = useState([]);
  const [rent, setRent] = useState({ id: 0 });

  const handleRentModal = () => setShowRentModal(!showRentModal);

  const handleConfirmModal = (id) => {
    if (id !== 0 && id !== undefined) {
      const rent = rents.filter((r) => r.id === id);
      setRent(rent[0]);
    } else {
      setRent({ id: 0 });
    }
    setSmshowConfirmModal(!smshowConfirmModal);
  };

  const getRents = async () => {
    const response = await api.get("Rent/read/all");
    return response.data;
  };

  const newRent = () => {
    setRent({ id: 0 });
    handleRentModal();
  };

  useEffect(() => {
    const catchRents = async () => {
      const all = await getRents();
      if (all) setRents(all);
    };
    catchRents();
  }, []);

  const addRent = async (r) => {
    handleRentModal();
    const response = await api.post("Rent/new", r);
    setRents([...rents, response.data]);
  };

  const deleteRent = async (id) => {
    handleConfirmModal(0);
    if (await api.delete(`Rent/delete/${id}`)) {
      const rentsFilter = rents.filter((r) => r.id !== id);
      setRents([...rentsFilter]);
    }
  };

  const cancelRent = () => {
    setRent({ id: 0 });
    handleRentModal();
  };

  const updateRent = async (r) => {
    handleRentModal();
    const response = await api.put("Rent/update/", r);
    const { id } = response.data;
    setRents(rents.map((item) => (item.id === id ? response.data : item)));
    setRent({ id: 0 });
  };

  const editRent = (id) => {
    const rent = rents.filter((r) => r.id === id);
    setRent(rent[0]);
    handleRentModal();
  };

  return (
    <>
      <TitlePage>
        <Button variant="primary" onClick={newRent}>
          <Plus size={22} weight="bold" />
        </Button>
      </TitlePage>

      <RentList
        rents={rents}
        editRent={editRent}
        handleConfirmModal={handleConfirmModal}
      />

      <Modal show={showRentModal} onHide={handleRentModal}>
        <Modal.Header closeButton>
          <Modal.Title>Locações</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <RentForm
            addRent={addRent}
            cancelRent={cancelRent}
            updateRent={updateRent}
            rentSelected={rent}
            rents={rents}
          />
        </Modal.Body>
      </Modal>

      <Modal size="sm" show={smshowConfirmModal} onHide={handleConfirmModal}>
        <Modal.Header closeButton>
          <Modal.Title>Excluir Locação</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          Tem certeza que deseja excluir essa locação?
        </Modal.Body>
        <Modal.Footer className="d-flex justify-content-between">
          <button
            className="btn btn-outline-success me-2"
            onClick={() => deleteRent(rent.id)}
          >
            <CheckCircle size={20} weight="bold" />
          </button>

          <button
            className="btn btn-danger me-2"
            onClick={() => handleConfirmModal(0)}
          >
            <XCircle size={20} weight="bold" />
          </button>
        </Modal.Footer>
      </Modal>
    </>
  )
}

export default Rent;
