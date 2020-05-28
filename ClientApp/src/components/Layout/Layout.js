import React from 'react';
import { Container } from 'reactstrap';
import { NavMenu } from './NavMenu';
import Footer from './Footer';

const Layout = ({ children }) => (
  < div >
    <NavMenu />
    <Container>
      {children}
    </Container>
    <Footer />
  </div >
);

export default Layout;
