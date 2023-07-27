import React, { useEffect } from 'react';
import { useParams, Link } from 'react-router-dom';
import PropTypes from 'prop-types';

import Spinner from '../layout/Spinner';
import Repos from '../repos/Repos';

const User = ({ getUser, getUserRepos, user, repos, loading }) => {
  const { loginName } = useParams();

  useEffect(() => {
    getUser(loginName);
    getUserRepos(loginName);
  }, [loginName]);

  const {
    name,
    avatar_url,
    location,
    bio,
    blog,
    login,
    html_url,
    followers,
    following,
    public_repos,
    public_gists,
    hireable,
    company,
  } = user;

  if (loading) return <Spinner />;
  else {
    return (
      <>
        <Link to='/' className='btn btn-light'>
          Back to search
        </Link>
        Hireable: {''}
        {hireable ? (
          <i className='fas fa-check text-success' />
        ) : (
          <i className='fas fa-times-circle text-danger' />
        )}
        <div className='card grid-2'>
          <div className='all-center'>
            <img
              src={avatar_url}
              alt=''
              className='round-img'
              style={{ width: '150px' }}
            />
            <h1>{name}</h1>
            <p>Location: {location}</p>
          </div>
          <div>
            {bio && (
              <>
                <h3>Bio</h3>
                <p>{bio}</p>
              </>
            )}
            <a href={html_url} target='_blank' className='btn btn-dark my-1'>
              Visit Github profile
            </a>
            <ul>
              <li>
                {login && (
                  <>
                    <strong>Username: </strong> {login}
                  </>
                )}
              </li>
              <li>
                {company && (
                  <>
                    <strong>Company: </strong> {company}
                  </>
                )}
              </li>
              <li>
                {blog && (
                  <>
                    <strong>blog: </strong> {blog}
                  </>
                )}
              </li>
            </ul>
          </div>
        </div>
        <div className='card text-center'>
          <div className='badge badge-primary'>Followers: {followers}</div>
          <div className='badge badge-success'>Following: {following}</div>
          <div className='badge badge-light'>Public Repos: {public_repos}</div>
          <div className='badge badge-dark'>Public Gist: {public_gists}</div>
        </div>
        <Repos repos={repos} />
      </>
    );
  }
};

User.prototype = {
  getUser: PropTypes.func.isRequired,
  getUserRepos: PropTypes.func.isRequired,
  user: PropTypes.object.isRequired,
  repos: PropTypes.array.isRequired,
  loading: PropTypes.bool.isRequired,
};

export default User;

/*

In React Router version 6, the withRouter HOC has been removed, and you can use the useParams 
hook directly within a function component to access the route params.

If you are using a class component and need to access the route params, you can use the useParams 
hook in a wrapper function component and then pass the params as props to your class component.

Here's how you can do it:

1. Create a wrapper function component that uses the useParams hook to get the route params.
2. Pass the route params as props to your class component.
3. Access the params in your class component through this.props.

  import React, { Component } from 'react';
  import { useParams } from 'react-router-dom';

  class UserClass extends Component {
    componentDidMount() {
      console.log('Check');
      console.log(this.props.login);
      //this.props.getUsers(this.props.match.params.login)
    }
    render() {
      return <div>User</div>;
    }
  }

  const User = () => {
    const params = useParams();

    return <UserClass {...params} />;
  };

  export default User;
*/
