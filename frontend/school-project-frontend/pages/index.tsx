import Head from 'next/head'

//using getStaticProps from next.js to pre-render my data from backend controller
export default function Home({ infos }: HomeProps) {

  return (
    <>
      <Head>
        <title>Akamali's school project</title>
        <meta name="description" content="School project" />
        <meta name="viewport" content="width=device-width, initial-scale=1" />
        <link rel="icon" href="/favicon.ico" />
      </Head>

      <div className='py-32 px-32'>
        <div>Hello, World!</div>
        <ul className='py-4'>
          <div className='grid grid-cols-4 gap-6'>
            {/* Looping data from backend to render page */}
            {infos.map(({ id, name, timeFrom, timeTo, cvrNR, address }) => (
              <div key={id} className='border-2 py-4 px-4 border-gray-500 mx-auto flex flex-col'>
                
                  <li className='font-sans text-xl p-1' key={name}>Business name: {name}</li>
                  <li className='font-sans text-xl py-1' key={timeFrom}>Opens: {timeFrom}</li>
                  <li className='font-sans text-xl py-1' key={timeTo}>Closes: {timeTo}</li>
                  <li className='font-sans text-xl py-1' key={cvrNR}>CVR Number: {cvrNR}</li>
                  <li className='font-sans text-xl py-1' key={address}>Address: {address}</li>
                  <div className='py-1' />
                
              </div>
            ))}
          </div>
        </ul>
      </div>
    </>
  )
}



//These are properties of object from my controller as interface
interface HomeProps {
  infos: {
    id: string;
    name: string;
    timeFrom: string;
    timeTo: string;
    cvrNR: string;
    address: string;
  }[];
}

//info about getStaticProps from next.js : https://nextjs.org/docs/basic-features/data-fetching/get-static-props
//This will make sure that Next.js will pre-render the page at build time
export async function getStaticProps() {
  //Backend controller api link
  const res = await fetch('http://localhost:5216/api/Info');

  //await to res and sends a JSON
  const infos = await res.json();

  //Return a json format using HomeProps interface
  return {
    props: {
      infos,
    }
  }
}