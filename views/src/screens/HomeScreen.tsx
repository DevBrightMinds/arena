import React, { useState, useEffect, useCallback } from "react";

import { MainServices } from "../utils/Services";

import Footer from "../components/Footer";
import NavBar from "../components/NavBar";
import ResultModal from "../components/ResultModal";

import { useDispatch } from "react-redux";
import { useNavigate } from "react-router-dom";

import Article from "../utils/interfaces/Article";
import { setSelectedArticle } from "../utils/Redux/Actions/MainActions";

const App: React.FC<{}> = (): JSX.Element => {
    const dispatch = useDispatch();
    const navigate = useNavigate();

    const Services = new MainServices();

    const [Feedback, setFeedback] = useState("");
    const [FeedbackHeading, setFeedbackHeading] = useState("");

    const [Status, setStatus] = useState(false);
    const [Loading, setLoading] = useState(true);

    const [Articles, setArticles] = useState<Article[]>([]);


    useEffect(() => {
        getArticles();

    }, [])

    const getArticles = () => {
        try {
            Services.GetArticles()
                .then((results: any) => {
                    setLoading(false);

                    if (results.Results.length > 0)
                        setArticles(results.Results);

                })
                .catch((error: any) => {
                    handleReporting(false, "Error", error.message);
                });
        } catch (error: any) {
            handleReporting(false, "Error", "Oops, something went wrong: Details -" + error.message);
        }
    }

    const handleReporting = (status: boolean, heading: string, feedback: string) => {
        setLoading(status);
        setFeedback(feedback);
        setFeedbackHeading(heading);
    }

    const toggleArticle = useCallback((article: Article) => {
        dispatch(setSelectedArticle(article));
        navigate("/article");

    }, [])

    const closeModal = useCallback(() => {
        setStatus(false);

    }, [Status])

    return <>
        <NavBar />
        <ResultModal status={Status} message={Feedback} heading={FeedbackHeading} closeModal={closeModal} />
        {Loading ?
            <div className="loader" style={{
                width: "30%",
                textAlign: "center",
                margin: "0 auto",
                padding: "20% 0 0 0"
            }}>
                <div className="spinner-border text-primary" role="status">
                </div>
            </div> :

            <div className="main-container" style={{ width: "80%", margin: "0 auto", padding: "2% 0 0 0" }}>
                <h4 className="container-heading">Avialable Articles</h4>

                <div className="articles-container" style={{ display: "flex", flexWrap: "wrap" }}>
                    {Articles.length > 0 ? Articles.map((article: Article, index: number) => {
                        return <div key={index} className="card" style={{ width: "15%", margin: "10px 0 10px 10px" }}>
                            <img className="card-img-top" style={{ height: "160px", objectFit: "cover" }} src={article.ImageUrl} alt="Card image cap" />
                            <div className="card-body">
                                <h5 className="card-title">{article.ArticleName}</h5>
                                <p className="card-text" style={{fontSize: "13px"}}>Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                                <button onClick={() => toggleArticle(article)} className="btn btn-primary" style={{ position: "absolute", bottom: 10 }}>Read More</button>
                            </div>
                        </div>
                    }) : "No articles available."}
                </div>
            </div>
        }

        <Footer />

    </>
}

export default App;