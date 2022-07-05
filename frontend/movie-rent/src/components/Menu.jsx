import { Navbar, Container, Nav, NavDropdown } from "react-bootstrap";
import { NavLink } from "react-router-dom";
import { Files } from "phosphor-react";

export default function Menu() {
  return (
    <Navbar bg="dark" expand="lg" variant="dark">
      <Container>
        <Navbar.Brand as={NavLink} to="/">
          LOCADORA
        </Navbar.Brand>
        <Navbar.Toggle aria-controls="basic-navbar-nav" />
        <Navbar.Collapse id="basic-navbar-nav">
          <Nav className="me-auto">
            <Nav.Link className={(navData) => navData.isActive ? 'Active' : ''}
              as={NavLink}
              to="/movie/list"
            >
              Filmes
            </Nav.Link>
            <Nav.Link className={(navData) => navData.isActive ? 'Active' : ''}
              as={NavLink}
              to="/client/list"
            >
              Clientes
            </Nav.Link>
            <Nav.Link className={(navData) => navData.isActive ? 'Active' : ''}
              as={NavLink}
              to="/rent/list"
            >
              Locações
            </Nav.Link>
          </Nav>
          <Nav>
          <Nav.Link className={(navData) => navData.isActive ? 'Active' : ''}
              as={NavLink}
              to="/reports"
            >
              <Files size={20} />
              Relatórios
            </Nav.Link>
            <NavDropdown
              align="end"
              title="Michel Claro"
              id="basic-nav-dropdown"
            >
              <NavDropdown.Item href="#action/3.3">Perfil</NavDropdown.Item>
              <NavDropdown.Divider />
              <NavDropdown.Item href="#action/3.4">Sair</NavDropdown.Item>
            </NavDropdown>
          </Nav>
        </Navbar.Collapse>
      </Container>
    </Navbar>
  );
}
