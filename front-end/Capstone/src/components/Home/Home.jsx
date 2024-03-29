function Home() {
  return (
    <>
      <div className="home">
        {/* è una applicazione per un salone di bellezza*/}
        <div className="home__container">
          <img
            src="https://images.unsplash.com/photo-1517849845537-4d257902454a?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=1050&q=80"
            alt=""
          />
          <div className="home__text">
            <h1>Benvenuti nel nostro salone di bellezza</h1>
            <h4>Il nostro salone di bellezza è il posto perfetto per rilassarsi e prendersi cura di se stessi. </h4>
            <h4>Il nostro team di professionisti è qui per aiutarti a sentirti e apparire al meglio.</h4>
          </div>
        </div>
      </div>
    </>
  );
}

export default Home;
