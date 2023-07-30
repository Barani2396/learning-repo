import React, { useContext } from 'react';
import { CSSTransition, TransitionGroup } from 'react-transition-group';

import ContactItems from './ContactItems';

import ContactContext from '../../context/contact/contactContext';

const Contacts = () => {
  const contactContext = useContext(ContactContext);

  const { contacts, filtered } = contactContext;

  if (contacts.length === 0) {
    return <h4>Please add a contact</h4>;
  }

  return (
    <>
      <TransitionGroup>
        {filtered != null
          ? filtered.map((contact) => (
              <CSSTransition key={contact.id} timeout={500} classNames='item'>
                <ContactItems contact={contact} />
              </CSSTransition>
            ))
          : contacts.map((contact) => (
              <CSSTransition key={contact.id} timeout={500} classNames='item'>
                <ContactItems contact={contact} />
              </CSSTransition>
            ))}
      </TransitionGroup>
    </>
  );
};

export default Contacts;
