using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using OSDevGrp.OSIntranet.CommonLibrary.Domain.Comparers;
using OSDevGrp.OSIntranet.CommonLibrary.Domain.Finansstyring;

namespace OSDevGrp.OSIntranet.CommonLibrary.Domain.Adressekartotek
{
    /// <summary>
    /// Basisklasse for en adresse.
    /// </summary>
    public abstract class AdresseBase : ICalculatable
    {
        #region Private variables

        private readonly int _nummer;
        private readonly IList<Bogføringslinje> _bogføringslinjer = new List<Bogføringslinje>();
        private string _navn;
        private Adressegruppe _adressegruppe;

        #endregion

        #region Constructors

        /// <summary>
        /// Danner en ny adresse.
        /// </summary>
        /// <param name="nummer">Unik identifikation af adressen.</param>
        protected AdresseBase(int nummer)
        {
            _nummer = nummer;
        }

        /// <summary>
        /// Danner en ny adresse.
        /// </summary>
        /// <param name="nummer">Unik identifikation af adressen.</param>
        /// <param name="navn">Navn.</param>
        /// <param name="adressegruppe">Adressegruppe.</param>
        protected AdresseBase(int nummer, string navn, Adressegruppe adressegruppe)
        {
            if (navn == null)
            {
                throw new ArgumentNullException("navn");
            }
            if (adressegruppe == null)
            {
                throw new ArgumentNullException("adressegruppe");
            }
            _nummer = nummer;
            _navn = navn;
            _adressegruppe = adressegruppe;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Unik identifikation af adressen.
        /// </summary>
        public virtual int Nummer
        {
            get
            {
                return _nummer;
            }
        }

        /// <summary>
        /// Navn.
        /// </summary>
        public virtual string Navn
        {
            get
            {
                return _navn;
            }
            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value");
                }
                _navn = value;
            }
        }

        /// <summary>
        /// Adresse (linje 1).
        /// </summary>
        public virtual string Adresse1
        {
            get;
            protected set;
        }

        /// <summary>
        /// Adresse (linje 2).
        /// </summary>
        public virtual string Adresse2
        {
            get;
            protected set;
        }

        /// <summary>
        /// Postnummer og by.
        /// </summary>
        public virtual string PostnrBy
        {
            get;
            protected set;
        }

        /// <summary>
        /// Telefon (1. nummer).
        /// </summary>
        protected virtual string Telefon1
        {
            get;
            set;
        }

        /// <summary>
        /// Telefon (2. nummer).
        /// </summary>
        protected virtual string Telefon2
        {
            get;
            set;
        }

        /// <summary>
        /// Telefon (3. nummer).
        /// </summary>
        protected virtual string Telefon3
        {
            get;
            set;
        }

        /// <summary>
        /// Adressegruppe.
        /// </summary>
        public virtual Adressegruppe Adressegruppe
        {
            get
            {
                return _adressegruppe;
            }
            protected set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                _adressegruppe = value;
            }
        }

        /// <summary>
        /// Bekendtskab.
        /// </summary>
        public virtual string Bekendtskab
        {
            get;
            protected set;
        }

        /// <summary>
        /// Mailadresse.
        /// </summary>
        public virtual string Mailadresse
        {
            get;
            protected set;
        }

        /// <summary>
        /// Webadresse.
        /// </summary>
        public virtual string Webadresse
        {
            get;
            protected set;
        }

        /// <summary>
        /// Betalingsbetingelse.
        /// </summary>
        public virtual Betalingsbetingelse Betalingsbetingelse
        {
            get;
            protected set;
        }

        /// <summary>
        /// Udlånsfrist.
        /// </summary>
        public virtual int Udlånsfrist
        {
            get;
            protected set;
        }

        /// <summary>
        /// Adresselabel til Filofix kalender.
        /// </summary>
        public virtual bool FilofaxAdresselabel
        {
            get;
            protected set;
        }

        /// <summary>
        /// Saldo pr. statusdato (beregnes ved hjælp af metoden Calculate).
        /// </summary>
        public virtual decimal SaldoPrStatusdato
        {
            get;
            protected set;
        }

        /// <summary>
        /// Bogføringslinjer.
        /// </summary>
        public virtual IEnumerable<Bogføringslinje> Bogføringslinjer
        {
            get
            {
                var comparer = new BogføringslinjeComparer();
                return new ReadOnlyCollection<Bogføringslinje>(_bogføringslinjer
                                                                   .OrderByDescending(m => m, comparer)
                                                                   .ToArray());
            }
        }

        #endregion

        #region ICalculatable Members

        /// <summary>
        /// Kalkulering af status på et givent tidspunkt.
        /// </summary>
        /// <param name="statusDato">Statusdato.</param>
        public void Calculate(DateTime statusDato)
        {
            Calculate(statusDato, int.MaxValue);
        }

        /// <summary>
        /// Kalkulering af status på et givent tidspunkt.
        /// </summary>
        /// <param name="statusDato">Statusdato.</param>
        /// <param name="løbenr">Den unikke identifikation af bogføringslinjen, som indgår i beregningen.</param>
        public void Calculate(DateTime statusDato, int løbenr)
        {
            SaldoPrStatusdato = Bogføringslinjer
                .Where(m => m.Løbenummer <= løbenr && m.Dato.CompareTo(statusDato) <= 0)
                .Sum(m => m.Debit - m.Kredit);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Navn på adressen.
        /// </summary>
        /// <returns>Navn på adressen.</returns>
        public override string ToString()
        {
            return Navn;
        }

        /// <summary>
        /// Opdaterer navn.
        /// </summary>
        /// <param name="navn">Navn.</param>
        public virtual void SætNavn(string navn)
        {
            Navn = Navn;
        }

        /// <summary>
        /// Sætter adresseoplysninger.
        /// </summary>
        /// <param name="adresse1">Adresse (linje 1).</param>
        /// <param name="adresse2">Adresse (linje 2).</param>
        /// <param name="postnrBy">Postnummer og by.</param>
        public virtual void SætAdresseoplysninger(string adresse1, string adresse2, string postnrBy)
        {
            Adresse1 = adresse1;
            Adresse2 = adresse2;
            PostnrBy = postnrBy;
        }

        /// <summary>
        /// Sætter telefonnumre.
        /// </summary>
        /// <param name="telefon1">Telefon (1. nummer).</param>
        /// <param name="telefon2">Telefon (2. nummer).</param>
        /// <param name="telefon3">Telefon (3. nummer).</param>
        protected virtual void SætTelefon(string telefon1, string telefon2, string telefon3)
        {
            Telefon1 = telefon1;
            Telefon2 = telefon2;
            Telefon3 = telefon3;
        }

        /// <summary>
        /// Opdaterer adressegruppe.
        /// </summary>
        /// <param name="adressegruppe">Adressegruppe.</param>
        public virtual void SætAdressegruppe(Adressegruppe adressegruppe)
        {
            Adressegruppe = adressegruppe;
        }

        /// <summary>
        /// Sætter bekendtskab.
        /// </summary>
        /// <param name="bekendtskab">Bekendtskab.</param>
        public virtual void SætBekendtskab(string bekendtskab)
        {
            Bekendtskab = bekendtskab;
        }

        /// <summary>
        /// Sætter mailadresse.
        /// </summary>
        /// <param name="mailadresse">Mailadresse.</param>
        public virtual void SætMailadresse(string mailadresse)
        {
            Mailadresse = mailadresse;
        }

        /// <summary>
        /// Sætter webadresse.
        /// </summary>
        /// <param name="webadresse">Webadresse.</param>
        public virtual void SætWebadresse(string webadresse)
        {
            Webadresse = webadresse;
        }

        /// <summary>
        /// Sætter betalingsbetingelse.
        /// </summary>
        /// <param name="betalingsbetingelse">Betalingsbetingelse.</param>
        public virtual void SætBetalingsbetingelse(Betalingsbetingelse betalingsbetingelse)
        {
            Betalingsbetingelse = betalingsbetingelse;
        }

        /// <summary>
        /// Sætter udlånsfrist.
        /// </summary>
        /// <param name="udlånsfrist">Udlånsfrist-</param>
        public virtual void SætUdlånsfrist(int udlånsfrist)
        {
            Udlånsfrist = udlånsfrist;
        }

        /// <summary>
        /// Sætter adresselabel til Filofax kalender.
        /// </summary>
        /// <param name="filofaxAdresselabel">Angivelse af adresselabel til Filofax kalender.</param>
        public virtual void SætFilofaxAdresselabel(bool filofaxAdresselabel)
        {
            FilofaxAdresselabel = filofaxAdresselabel;
        }
        
        /// <summary>
        /// Tilføjer en bogføringslinje til adressen.
        /// </summary>
        /// <param name="bogføringslinje">Bogføringslinje.</param>
        public virtual void TilføjBogføringslinje(Bogføringslinje bogføringslinje)
        {
            if (bogføringslinje == null)
            {
                throw new ArgumentNullException("bogføringslinje");
            }
            bogføringslinje.SætAdresse(this);
            _bogføringslinjer.Add(bogføringslinje);
        }

        #endregion
    }
}
